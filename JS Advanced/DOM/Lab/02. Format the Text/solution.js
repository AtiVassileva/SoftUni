function solve() {
  let text = document.getElementById('input').innerText;
  let sentences = text.split('.');
  let output = document.getElementById('output');


  while (sentences.length > 0) {
    let currentParagraph = sentences.splice(0, 3).join('.') + '.';
    let paragraph = document.createElement('p');
    paragraph.innerText = currentParagraph;
    output.appendChild(paragraph);
  }
}