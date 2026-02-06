window.myJsFunction = function (e, sfId) {
    if (!window.sfBlazor || !sfBlazor.instances) {
        console.warn('sfBlazor not available');
        return;
    }

    const editor = sfBlazor.instances[sfId];
    if (!editor) {
        console.warn('Editor instance not found for ID:', sfId);
        return;
    }

    const id = editor.dataId + 'mirror-view';
    const rteContainer = editor.element
        ? editor.element.querySelector('.e-rte-container')
        : null;

    if (!rteContainer) {
        console.warn('RTE container not found');
        return;
    }

    let mirrorView = editor.element.querySelector('#' + id);

    // When user switches back from Code view to Preview
    if (e && e.requestType === 'Preview') {
        if (myCodeMirror) {
            editor.value = myCodeMirror.getValue();
        }
        rteContainer.classList.remove('e-rte-code-mirror-enabled');
        editor.focusIn && editor.focusIn();
        return;
    }

    // Switch to Code view
    rteContainer.classList.add('e-rte-code-mirror-enabled');
    rteContainer.classList.remove('e-source-code-enabled');

    // Create the host div once
    if (!mirrorView) {
        mirrorView = document.createElement('div');
        mirrorView.classList.add('rte-code-mirror');
        mirrorView.style.display = 'none';
        mirrorView.id = id;
        rteContainer.appendChild(mirrorView);

        renderCodeMirror(mirrorView, editor.value == null ? '' : editor.value);
    } else if (myCodeMirror) {
        // Update with latest editor content if instance already exists
        myCodeMirror.setValue(editor.value == null ? '' : editor.value);
        myCodeMirror.refresh();
    }

    if (myCodeMirror) {
        myCodeMirror.focus();
    }

    function renderCodeMirror(host, content) {
        if (typeof window.CodeMirror === 'undefined') {
            console.error('CodeMirror is not loaded');
            return;
        }

        myCodeMirror = window.CodeMirror(host, {
            value: content,
            theme: 'monokai',
            lineNumbers: true,
            mode: 'text/html',
            lineWrapping: true
        });

        myCodeMirror.refresh();
    }
};