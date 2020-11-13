function solve(currFace, currSuit) {
    let cardFaces = [2, 3, 4, 5, 6, 7, 8, 9, 10, 'J', 'Q', 'K', 'A'];
    let cardSuits = {
        'S': '\u2660',
        'H': '\u2665 ',
        'D': '\u2666 ',
        'C': '\u2663 ',
    }

    if (!cardFaces.includes(currFace) || cardSuits[currSuit] === undefined) {
        throw new Error('Invalid data!');
    }

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
            if (cardSuits[value] === undefined) {
                throw new Error('Invalid face!');
            }

            this._suit = value;
        }

        toString(){
            return `${this.face}${this.suit}`;
        }
    }

    let card = new Card(currFace, cardSuits[currSuit]);
    return card;
}