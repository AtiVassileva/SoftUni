function solve() {
    let firstPlayerCards = document.getElementById('player1Div');
    let secondPlayerCards = document.getElementById('player2Div');

    let leftSpan = document.querySelectorAll('#result > span')[0];
    let rightSpan = document.querySelectorAll('#result > span')[2];
    let historyDiv = document.getElementById('history');

    let opponentCards = [];

    firstPlayerCards.addEventListener('click', (e) => {
        e.target.src = 'images/whiteCard.jpg';
        leftSpan.textContent = e.target.name;
        opponentCards[0] = e;
        checkWinner();
    });

    secondPlayerCards.addEventListener('click', (e) => {
        e.target.src = 'images/whiteCard.jpg';
        rightSpan.textContent = e.target.name;
        opponentCards[1] = e;
        checkWinner();
    });

    function checkWinner(){
        if (opponentCards.length === 2) {
            let firstCard = opponentCards[0].target;
            let secondCard = opponentCards[1].target;

            if (Number(firstCard.name) > Number(secondCard.name)) {
                firstCard.style.border = '2px solid green';
                secondCard.style.border = '2px solid red';
            } else {
                firstCard.style.border = '2px solid red';
                secondCard.style.border = '2px solid green';
            }

            historyDiv.textContent += `[${firstCard.name} vs ${secondCard.name}] `;
            opponentCards = [];
        }
    }
}