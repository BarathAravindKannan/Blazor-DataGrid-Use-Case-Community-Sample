window.openPrintWindow = (content) => {
    sfBlazor.Grid.printGrid = function (e) {
        let printWindow = window.open("", "_blank", "width=" + window.outerWidth + ",height=" + window.outerHeight);
        if (printWindow) {
            printWindow.document.write(content);
            printWindow.document.close();
            printWindow.print();
        } else {
            console.error("Print window could not be opened.");
        }
    }
};