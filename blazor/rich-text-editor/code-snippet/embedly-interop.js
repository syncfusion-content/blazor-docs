window.embedlyInterop = {
    wrapLinkInEmbedlyCard: function() {
        const rteContent = document.querySelector('.e-rte-content');
        if (!rteContent) {
            return;
        }
        const links = rteContent.querySelectorAll('a');
        links.forEach(link => {
            if (!link.closest('.embedly-card')) {
                const blockquote = document.createElement('blockquote');
                blockquote.className = 'embedly-card';
                const anchor = document.createElement('a');
                anchor.href = link.href;
                anchor.textContent = link.textContent || link.href;
                blockquote.appendChild(anchor);
                blockquote.appendChild(document.createElement('p'));
                link.parentNode.replaceChild(blockquote, link);
            }
        });
        if (window.embedly && window.embedly.lib) {
            window.embedly.lib.process(rteContent);
        }
    }
};
// Initialize Embedly processing on page load
function initializeEmbedly() {
    if (window.embedly && window.embedly.lib) {
        window.embedly.lib.process(document.body);
    }
}