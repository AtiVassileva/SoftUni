function growingWord() {
  let parentElement = document.getElementById('exercise');
  let growingWordElement = parentElement.lastElementChild;
  let colors = document.getElementById('colors');

  if (!growingWordElement.style.fontSize) {
    growingWordElement.style.fontSize = '2px';
  } else {
    growingWordElement.style.fontSize = parseInt(growingWordElement.style.fontSize) * 2 + 'px';
  }

  let firstElement = colors.firstElementChild;
  let currentColor = firstElement.innerHTML.toLowerCase();
  growingWordElement.style.color = currentColor;

  colors.appendChild(firstElement);
}