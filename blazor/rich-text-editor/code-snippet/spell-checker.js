window.initializeWebSpellChecker = function (sfId) {
    if (!window.sfBlazor || !sfBlazor.instances) {
        console.warn('sfBlazor not available');
        return;
    }

    const editor = sfBlazor.instances[sfId];
    if (!editor) {
        console.warn('Editor instance not found for ID:', sfId);
        return;
    }

    const rteContainer = editor.element
        ? editor.element.querySelector('.e-rte-container')
        : null;

    if (!rteContainer) {
        console.warn('RTE container not found');
        return;
    }
    window.WEBSPELLCHECKER_CONFIG = {
        // Get the activation key from your registered account
        serviceId: 'Your activation key',
        autoSearch: true,
        lang: 'en_US',
        selectors: [
            { selector: rteContainer }            
        ],
        // Optional:
        // theme: 'gray',
    };
    const tryInitialize = () => {
        if (window.WEBSPELLCHECKER && typeof window.WEBSPELLCHECKER.startAutoSearch === 'function') {
            window.WEBSPELLCHECKER.startAutoSearch();
            console.log('WProofreader initialized successfully');
        } else {
            console.log('WProofreader not ready yet — retrying...');
            setTimeout(tryInitialize, 300);
        }
    };

    tryInitialize();
};
