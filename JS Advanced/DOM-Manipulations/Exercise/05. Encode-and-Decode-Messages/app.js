function encodeAndDecodeMessages() {
    let buttons = document.getElementsByTagName('button');
    let textAreas = document.getElementsByTagName('textarea');

    let encodeButton = buttons[0];
    let decodeButton = buttons[1];

    let encodeArea = textAreas[0];
    let decodeArea = textAreas[1];

    encodeButton.addEventListener('click', () => {
        let result = [];
        for (let i = 0; i < encodeArea.value.length; i++) {
            result [i] = encodeArea.value.charCodeAt(i) + 1;    
        }

        decodeArea.textContent = result.map(x => String.fromCharCode(x)).join('');
        encodeArea.value = '';
    });

    decodeButton.addEventListener('click', () => {
        let result = [];
        for (let i = 0; i < decodeArea.textContent.length; i++) {
            result [i] = decodeArea.textContent.charCodeAt(i) - 1;    
        }

        decodeArea.textContent = result.map(x => String.fromCharCode(x)).join('');
    })
}