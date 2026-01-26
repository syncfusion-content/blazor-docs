---
layout: post
title: MCP Integration with Blazor AI AssistView Component | Syncfusion
description: Checkout and learn about MCP integration with Blazor AI AssistView component in Blazor WebAssembly Application.
platform: Blazor
control: AI AssistView
documentation: ug
---

# Integrate MCP Server with Blazor AI AssistView Component

The AI AssistView component integrates with a [Model Context Protocol](https://modelcontextprotocol.io/docs/getting-started/intro) (MCP) backend to enable conversational AI features powered by OpenAI, along with [local tool](https://modelcontextprotocol.io/docs/develop/connect-local-servers) capabilities such as file-aware analysis via `@mentions` using the [Mention](https://ej2.syncfusion.com/blazor/documentation/mention/getting-started) component. This integration allows the component to reference files in prompts using the filenames(`@filename`), inject their contents into the model context, and enables analysis of those files alongside the user prompt.

## Prerequisites

Before integrating `MCP Server`, ensure the following:

1. `Node.js`: Version 16 or higher, along with npm installed.

2. `OpenAI Account`: Access to OpenAI services and a generated API key.

3. `Syncfusion AI AssistView`: Install the package [@syncfusion/ej2-angular-interactive-chat](https://www.nuget.org/packages/Syncfusion.Blazor.InteractiveChat).

4. `Marked Library`: For parsing Markdown responses [Markdig](https://www.nuget.org/packages/Markdig).

## Set Up the AI AssistView Component

Follow the [Getting Started](../getting-started) guide to configure and render the AI AssistView component in the application and that prerequisites are met.

## Install server dependencies

Create a folder for the MCP server (e.g., `mcp-demo`) and install the required packages:

```bash

npm install express cors @modelcontextprotocol/sdk

```

## Configure the MCP Server

Create a file named `mcp-server.mjs` in your server folder. This server will:

* Expose `MCP-style SSE endpoints`:
    * `GET /events` – Server-Sent Events stream for clients to subscribe to.
    * `POST /messages` – Accepts client messages and broadcasts them to the corresponding SSE stream.
* Register `tools`:
    * `text.generate` → Calls OpenAI Chat Completions to generate responses.
    * `fs.read` → Reads a file under a configured base directory only.
* Provide a `REST endpoint`:
    * `POST /assist/chat` – A simple REST interface that your Angular app can call.
* Detect `@filename` tokens in prompts, read the file contents, and attach them to the conversation for contextual analysis.
* Maintain session history in memory using a `sessionId` sent from the client.

>Note: This implementation uses `Node.js ESM`, `express`, `cors`, and `@modelcontextprotocol/sdk`. It also expects an OpenAI API key via OPENAI_API_KEY.

### Configure OpenAI with MCP Server

1. Sign up or log in to [OpenAI](https://platform.openai.com/login/) and navigate to your [API Keys](https://platform.openai.com/settings/organization/api-keys) page.

2. Generate a new `API key` or use an existing one.

3. Store this API key securely, as it will be used in MCP server.

```bash

const OPENAI_API_KEY = "YOUR_OPENAI_API_KEY";

const resp = await fetch('https://api.openai.com/v1/chat/completions', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json', 'Authorization': `Bearer ${OPENAI_API_KEY}` },
    body: JSON.stringify({
        model, // Your AI model
        messages: [{ role: 'user', content: String(prompt ?? '') }],
        temperature,
        max_tokens,
        stream: false
    })
});

```

> `Security Note`: Never expose your API key in client-side code for production applications. Use a server-side proxy or environment variables to manage sensitive information securely.

{% tabs %}
{% highlight c# tabtitle="mcp-server.mjs" %}

import express from 'express';
import cors from 'cors';
import { Server } from '@modelcontextprotocol/sdk/server/index.js';
import { SSEServerTransport } from '@modelcontextprotocol/sdk/server/sse.js';
import { ListToolsRequestSchema, CallToolRequestSchema } from '@modelcontextprotocol/sdk/types.js';
import path from 'node:path';
import fs from 'node:fs/promises';

const app = express();
// CORS for Angular app
app.use(
  cors({
    origin: [
      'http://localhost:4200',
      'http://127.0.0.1:4200'
    ],
    methods: ['POST', 'OPTIONS']
  })
);
// No global body parser for SSE routes; let the transport read the stream directly.

// Low-level MCP server (compatible with SSE transport)
const server = new Server(
  { name: 'openai-mcp-sse', version: '1.0.0' },
  { capabilities: { tools: {} } }
);

const FS_BASE_DIR = "";
const OPENAI_API_KEY = "";

// In-memory session store: sessionId -> [{ role: 'user'|'assistant', content: string }]
// Note: In production, replace with a durable store (Redis, DB).
const sessions = new Map();

function getSession(sessionId) {
  if (!sessionId) return null;
  if (!sessions.has(sessionId)) sessions.set(sessionId, []);
  return sessions.get(sessionId);
}

function appendMessage(sessionId, role, content, maxTurns = 10) {
  const hist = getSession(sessionId);
  if (!hist) return;
  hist.push({ role, content });
  // keep only the last maxTurns pairs (~2*maxTurns messages)
  const maxMsgs = maxTurns * 2;
  if (hist.length > maxMsgs) {
    sessions.set(sessionId, hist.slice(-maxMsgs));
  }
}

function safeJoin(base, target) {
  const full = path.resolve(base, target);
  if (!full.startsWith(path.resolve(base))) {
    throw new Error('Path traversal not allowed');
  }
  return full;
}

// Expose tools via tools/list
server.setRequestHandler(ListToolsRequestSchema, async () => ({
  tools: [
    {
      name: 'text.generate',
      description: 'Generate text via OpenAI Chat Completions',
      inputSchema: {
        type: 'object',
        properties: {
          prompt: { type: 'string' },
          temperature: { type: 'number' },
          max_tokens: { type: 'number' },
          model: { type: 'string' }
        },
        required: ['prompt']
      }
    },
    {
      name: 'fs.read',
      description: `Read a UTF-8 text file under ${FS_BASE_DIR}`,
      inputSchema: {
        type: 'object',
        properties: { relPath: { type: 'string' }, maxBytes: { type: 'number' } },
        required: ['relPath']
      }
    }
  ]
}));

// Handle tools/call
server.setRequestHandler(CallToolRequestSchema, async (request) => {
  const { name, arguments: args = {} } = request.params;

  if (name === 'text.generate') {
    if (!OPENAI_API_KEY) {
      return { isError: true, content: [{ type: 'text', text: 'Missing OPENAI_API_KEY' }] };
    }
    const { prompt, temperature = 0.7, max_tokens = 350, model = 'gpt-4o-mini' } = args;
    try {
      const resp = await fetch('https://api.openai.com/v1/chat/completions', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', 'Authorization': `Bearer ${OPENAI_API_KEY}` },
        body: JSON.stringify({ model, messages: [{ role: 'user', content: String(prompt ?? '') }], temperature, max_tokens, stream: false })
      });
      if (!resp.ok) {
        const err = await resp.text();
        return { isError: true, content: [{ type: 'text', text: `OpenAI error ${resp.status}: ${err.slice(0,500)}` }] };
      }
      const data = await resp.json();
      const text = data?.choices?.[0]?.message?.content ?? '';
      console.log(text);
      return { content: [{ type: 'text', text }] };
    } catch (e) {
      return { isError: true, content: [{ type: 'text', text: `OpenAI fetch failed: ${String(e)}` }] };
    }
  }

  if (name === 'fs.read') {
    try {
      const rel = String(args.relPath || '');
      const full = safeJoin(FS_BASE_DIR, rel);
      const stat = await fs.stat(full);
      if (!stat.isFile()) return { isError: true, content: [{ type: 'text', text: 'Not a file' }] };
      const max = Math.min(Number(args.maxBytes || 200000), 2_000_000);
      const data = await fs.readFile(full);
      const buf = data.slice(0, max);
      const text = buf.toString('utf8');
      return { content: [{ type: 'text', text }] };
    } catch (e) {
      return { isError: true, content: [{ type: 'text', text: `fs.read error: ${String(e)}` }] };
    }
  }
  return { isError: true, content: [{ type: 'text', text: 'Unknown tool' }] };
});

let transport;

// SSE endpoint for events
app.get('/events', async (_req, res) => {
  transport = new SSEServerTransport('/messages', res);
  await server.connect(transport);
});

// POST endpoint for client messages
app.post('/messages', async (req, res) => {
  if (!transport) return res.status(400).send('No active transport');
  await transport.handlePostMessage(req, res);
});

// Simple REST endpoint for AssistView (avoids separate proxy)
app.post('/assist/chat', express.json(), async (req, res) => {
  try {
    const { sessionId, prompt, temperature = 0.7, max_tokens = 350, model = 'gpt-4o-mini' } = req.body || {};
    if (!prompt) return res.status(400).json({ error: 'Prompt is required' });
    const sid = String(sessionId || '');
    // Otherwise call OpenAI with @mention file support
    if (!OPENAI_API_KEY) return res.status(500).json({ error: 'Missing OPENAI_API_KEY' });

    // Resolve @mentions in the prompt. Supports @path and @"path with spaces" and @'path with spaces'
    async function resolveMentions(input) {
      const re = /@(?:"([^"]+)"|'([^']+)'|([A-Za-z0-9_\\\/\.\-]+))/g;
      const unique = new Set();
      let m;
      while ((m = re.exec(input)) !== null) {
        const p = m[1] || m[2] || m[3];
        if (p) unique.add(p);
      }
      const files = [];
      for (const p of unique) {
        try {
          const full = safeJoin(FS_BASE_DIR, p);
          const stat = await fs.stat(full);
          if (stat.isFile()) {
            const data = await fs.readFile(full);
            const text = data.subarray(0, 200000).toString('utf8');
            files.push({ path: p, content: text });
          }
        } catch {
          // ignore invalid paths
        }
      }
      return files;
    }

    const attachments = await resolveMentions(String(prompt));

    // Build messages with session history and any attached file contents
    const history = getSession(sid) || [];
    const messages = [...history];
    if (attachments.length) {
      const joined = attachments
        .map(a => `File: ${a.path}\n--- START ---\n${a.content}\n--- END ---`)
        .join('\n\n');
      messages.push({ role: 'user', content: `Here are referenced files via @mentions:\n${joined}` });
    }
    messages.push({ role: 'user', content: String(prompt) });

    const resp = await fetch('https://api.openai.com/v1/chat/completions', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json', 'Authorization': `Bearer ${OPENAI_API_KEY}` },
      body: JSON.stringify({ model, messages, temperature, max_tokens, stream: false })
    });
    if (!resp.ok) {
      const err = await resp.text();
      return res.status(resp.status).json({ error: 'OpenAI error', details: err.slice(0, 500) });
    }
    const data = await resp.json();
    const content = data?.choices?.[0]?.message?.content ?? '';

    // Update session history
    if (sid) {
      appendMessage(sid, 'user', String(prompt));
      appendMessage(sid, 'assistant', content);
    }

    res.json({ content, raw: data });
  } catch (e) {
    res.status(500).json({ error: String(e?.message || e) });
  }
});

// Clear a session's history
app.post('/assist/clear', express.json(), (req, res) => {
  const { sessionId } = req.body || {};
  if (sessionId && sessions.has(sessionId)) sessions.delete(sessionId);
  res.json({ ok: true });
});

const port = Number(process.env.PORT || 3000);
const host = '0.0.0.0';
app.listen(port, host, () => {
  console.log(`MCP SSE server running at http://localhost:${port}`);
  console.log(`SSE endpoint: http://localhost:${port}/events`);
  console.log(`REST assist endpoint: http://localhost:${port}/assist/chat`);
  console.log(`FS base dir: ${FS_BASE_DIR}`);
});

{% endhighlight %}
{% highlight c# tabtitle="package.json" %}

{
  "name": "mcp-demo",
  "version": "1.0.0",
  "main": "index.js",
  "scripts": {
    "test": "echo \"Error: no test specified\" && exit 1"
  },
  "keywords": [],
  "author": "",
  "license": "ISC",
  "description": "",
  "dependencies": {
    "@modelcontextprotocol/sdk": "^1.20.2",
    "express": "^5.1.0",
    "zod": "^3.25.76"
  }
}

{% endhighlight %}
{% endtabs %}

## Configure AI AssistView with MCP Server

To integrate the MCP server with the AI AssistView component, update the `home.razor` file in your Angular application.

You can type `@` in the prompt box to select and mention files. The contents of these mentioned files will be included in the AI context, enabling more accurate and code-aware responses.

In the following example, the [PromptRequested](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfAIAssistView.html#Syncfusion_Blazor_InteractiveChat_SfAIAssistView_PromptRequested) event sends the user’s prompt (including any `@mentions`) to the MCP server endpoint `/assist/chat`. The server:
    * Extracts unique file mentions from the prompt.
    * Safely reads those files from the configured FS_BASE_DIR.
    * Injects their contents into the conversation as contextual messages.

OpenAI then receives both the original prompt and the attached file contents, allowing it to provide `code-aware analysis and responses`.

``` bash

const FS_BASE_DIR = "YOUR_FS_BASE_DIR";

// Expose tools via tools/list
server.setRequestHandler(ListToolsRequestSchema, async () => ({
  tools: [
    {
      name: 'fs.read',
      description: `Read a UTF-8 text file under ${FS_BASE_DIR}`,
      inputSchema: {
        type: 'object',
        properties: { relPath: { type: 'string' }, maxBytes: { type: 'number' } },
        required: ['relPath']
      }
    }
  ]
}));

```

> The component uses a `session ID` to maintain conversation history. It is stored in `localStorage` and sent with each request. The MCP server keeps session data in memory, and clicking Clear Prompts resets the session via `/assist/clear`.

{% tabs %}
{% highlight c# tabtitle="mcp-server.mjs" %}

@using Syncfusion.Blazor.InteractiveChat
@using Markdig
@inject IJSRuntime JSRuntime
@inject IHttpClientFactory HttpClientFactory

<div class="aiassist-container" style="height: 350px; width: 650px;">
    <SfAIAssistView ID="aiAssist" @ref="sfAIAssistView" Created="OnAssistCreated" PromptRequested="OnPromptRequest" ResponseStopped="OnStopRespondingClick">
        <AssistViewToolbar ItemClicked="ToolbarItemClicked">
            <AssistViewToolbarItem IconCss="e-icons e-refresh" Tooltip="Clear Prompts"></AssistViewToolbarItem>
        </AssistViewToolbar>
    </SfAIAssistView>
</div>

@code {
    private SfAIAssistView sfAIAssistView;
    private bool stopStreaming = false;
    private string sessionId = string.Empty;
     private bool _isClientReady;
    private string? _storedValue;

    private void ToolbarItemClicked(AssistViewToolbarItemClickedEventArgs args)
    {
        if (args.Item.IconCss == "e-icons e-refresh")
        {
            sfAIAssistView.Prompts.Clear();
        }
    }

    protected override async Task OnInitializedAsync()
    {
        // Persist sessionId like Angular sample
        var existing = await GetLocalStorage("assist_session");
        if (!string.IsNullOrWhiteSpace(existing))
        {
            sessionId = existing!;
        }
        else
        {
            sessionId = Guid.NewGuid().ToString("N");
            await SetLocalStorage("assist_session", sessionId);
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            // Safe to use JS interop now
            _isClientReady = true;

            // Example: read a value once interactive
            _storedValue = await GetLocalStorage("myKey");

            // Update UI with the read value
            StateHasChanged();
        }
    }

    // Files for @mentions (same as Angular sample)
    private readonly string[] files = new[]
    {
        "Home.razor"
    };

    private async Task OnAssistCreated()
    {
        await JSRuntime.InvokeVoidAsync("assistMention.init", ".e-aiassistview [contenteditable='true']", files);
    }

    private async Task OnPromptRequest(AssistViewPromptRequestedEventArgs args)
    {
        try
        {
            var client = HttpClientFactory.CreateClient("AssistAPI");
            var payload = new
            {
                sessionId,
                prompt = args.Prompt,
                model = "gpt-4o-mini",
                temperature = 0.2,
                max_tokens = 512
            };
            var res = await client.PostAsJsonAsync("assist/chat", payload);
            if (!res.IsSuccessStatusCode)
            {
                var err = await res.Content.ReadAsStringAsync();
                await sfAIAssistView.UpdateResponseAsync($"⚠️ Failed to connect to server. {err}");
                stopStreaming = true;
                return;
            }
            var data = await res.Content.ReadFromJsonAsync<AssistResponse>();
            var responseText = (data?.content ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(responseText))
            {
                responseText = "No response received.";
            }
            stopStreaming = false;
            await StreamResponseAsync(responseText);
        }
        catch (Exception ex)  // Adding exception variable for more detail
        {
            await sfAIAssistView.UpdateResponseAsync($"⚠️ Failed to connect to server. Ensure MCP server is running at http://localhost:3000. Error: {ex.Message}");
            stopStreaming = true;
        }
    }

    private async Task StreamResponseAsync(string response)
    {
        // Chunked updates (like Angular’s streamResponse)
        var lastResponse = string.Empty;
        int responseUpdateRate = 10;
        for (int i = 0; i < response.Length && !stopStreaming; i++)
        {
            lastResponse += response[i];
            if (i % responseUpdateRate == 0 || i == response.Length - 1)
            {
                var html = Markdig.Markdown.ToHtml(lastResponse);
                await sfAIAssistView.UpdateResponseAsync(html);
                await sfAIAssistView.ScrollToBottomAsync();
                await Task.Delay(15);
            }
        }
    }

    private async Task OnStopRespondingClick()
    {
        stopStreaming = true;
        await Task.CompletedTask;
    }

    private async Task ResetSessionAsync()
    {
        var previous = sessionId;
        sessionId = Guid.NewGuid().ToString("N");
        SetLocalStorage("assist_session", sessionId);

        try
        {
            var client = HttpClientFactory.CreateClient("AssistAPI");
            await client.PostAsJsonAsync("assist/clear", new { sessionId = previous });
        }
        catch
        {
            // ignore
        }
    }

    // Retrieves a value from browser local storage (only after client ready)
    private async Task<string?> GetLocalStorage(string key)
    {
        if (!_isClientReady) return null; // or throw; guard against prerender
        return await JSRuntime.InvokeAsync<string?>("localStorage.getItem", key);
    }

    // Sets a value in browser local storage (only after client ready)
    private async Task SetLocalStorage(string key, string value)
    {
        if (!_isClientReady) return; // guard against prerender
        await JSRuntime.InvokeVoidAsync("localStorage.setItem", key, value);
    }

    // Example handler triggered by a user action (safe after first render)
    private async Task SaveSomething()
    {
        await SetLocalStorage("myKey", "some value");
    }

    private sealed class AssistResponse
    {
        public string? content { get; set; }
    }

}

{% endhighlight %}
{% highlight c# tabtitle=".js" %}

window.assistMention = {
    init: function (selector, files) {
        const target = document.querySelector(selector);
        if (!target) return;
        // Remove old instance if any
        if (target.__sfMention) {
            try { target.__sfMention.destroy(); } catch { }
            target.__sfMention = null;
        }
        // Create container for Mention
        const host = document.createElement('div');
        document.body.appendChild(host);

        // eslint-disable-next-line no-undef
        const mention = new ej.dropdowns.Mention({
            target: target,
            showMentionChar: true,
            dataSource: files,
            change: function () {
                const ev = new Event('input', { bubbles: true });
                target.dispatchEvent(ev);
            }
        });
        mention.appendTo(host);
        target.__sfMention = mention;
    }
};

{% endhighlight %}
{% highlight c# tabtitle="Server(~/_Program.cs)" %}

builder.Services.AddHttpClient("AssistAPI", client =>
{
    client.BaseAddress = new Uri("http://localhost:3000/");
});

{% endhighlight %}
{% endtabs %}

## Run and Test

### Start the MCP server:

Navigate to your MCP server folder and run the following command to start the Node.js server:

```bash

node mcp-server.mjs

```

### Start the frontend:

In a separate, navigate to your project folder and start the development server:

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application.

Open your app to interact with the AI AssistView component integrated with MCP.

## Troubleshooting

* `401/403 from OpenAI`: Verify your `OPENAI_API_KEY` and model deployment name.
* `File path errors`: Ensure FS_BASE_DIR is correctly set and paths are relative to it.
* `CORS issues`: Confirm the server allows requests from `http://localhost:4200`.
* `SSE stream testing`: Run `curl -N http://localhost:3000/events` to verify the stream is active.