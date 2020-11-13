function printDeckOfCards(cards) {
    let cardFaces = [2, 3, 4, 5, 6, 7, 8, 9, 10, 'J', 'Q', 'K', 'A'];
    let cardSuits = {
        'S': '\u2660',
        'H': '\u2665 ',
        'D': '\u2666 ',
        'C': '\u2663 ',
    }

    let allCards = [];

    for (let i = 0; i < cards.length; i++) {
        let currentCard = cards[i];
        let face = currentCard.length === 3 ? currentCard[0] + currentCard[1] :
            currentCard[0];
        let parsedFace = isNaN(Number(face)) ? face : Number(face);
        let suit = currentCard[currentCard.length - 1];

        if (!cardFaces.includes(parsedFace) || cardSuits[suit] === undefined) {
            console.log(`Invalid card: ${face}${suit}`);
            continue;
        }

        let card = createCard(parsedFace, suit);
        allCards.push(card.toString());
    }

    console.log(allCards.join(' '));

    function createCard(currFace, currSuit) {

        class Card {
            constructor(face, suit) {
                this.face = face;
                this.suit = suit;
            }

            get face() {
                return this._face;
            }

            set face(value) {
                if (!cardFaces.includes(value)) {
                    throw new Error('Invalid face!');
                }
                this._face = value;
            }

            get suit() {
                return this._suit;
            }

            set suit(value) {
                if (!cardSuits[value] === undefined) {
                    throw new Error('Invalid face!');
                }

                this._suit = value;
            }

            toString() {
                return `${this.face}${this.suit}`;
            }
        }

        let card = new Card(currFace, cardSuits[currSuit]);
        return card;
    }
}