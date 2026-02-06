window.canvasInterop = {
    detectedFormat: null
};

window.rteInterop = {
    objRef: null,
    onInitialized: function (objRef) {
        window.rteInterop.objRef = objRef;
        var fileInput = document.getElementById('rte-img-upload');
        if (fileInput) {
            fileInput.onchange = function (e) {
                if (e.target.files && e.target.files.length > 0) {
                    var file = e.target.files[0];  
                    window.canvasInterop.detectedFormat = file.type;
                    var reader = new FileReader();
                    reader.onload = function (event) {
                        window.rteInterop.objRef.invokeMethodAsync('FileSelected', event.target.result);
                    };
                    reader.readAsDataURL(file);
                    e.target.value = '';
                }
            };
        }
        return true;
    },
    fileSelect: function () {
        var inputFile = document.getElementById('rte-img-upload');
        if (inputFile) {
            inputFile.click();
        }
        return true;
    },
    getEditedImageData: function () {
        var imageEditor = document.querySelector('.e-image-editor');
        if (!imageEditor) {
            return '';
        }
        var dataId = imageEditor.getAttribute('data-control-id');
        var instance = null;
        
        if (!dataId && window.sfBlazor) {
            instance = window.sfBlazor.getCompInstance(imageEditor);
        } else if (dataId && window.sfBlazor) {
            instance = window.sfBlazor.getCompInstance(dataId);
        }
        
        if (instance && instance.getImageData) {
            var imageData = instance.getImageData();
            if (imageData) {
                var tempCanvas = document.createElement('canvas');
                tempCanvas.width = imageData.width;
                tempCanvas.height = imageData.height;
                var ctx = tempCanvas.getContext('2d');
                ctx.putImageData(imageData, 0, 0); 
                if (window.canvasInterop.detectedFormat) {
                    return tempCanvas.toDataURL(window.canvasInterop.detectedFormat);
                } else {
                    return tempCanvas.toDataURL();
                }
            }
        }
        return '';
    }
};