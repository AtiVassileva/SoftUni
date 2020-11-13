let assert = require('chai').assert;
let app = require('./even-or-odd');

describe('Test EvensAndOdds', () => {
    it('Should return odd with string with odd length', () => {
        assert.equal(app.isOddOrEven('words'), 'odd');
    });
    it('Should return even with string with even length', () => {
        assert.equal(app.isOddOrEven('word'), 'even');
    });
    it('Should return undefined with number parameter', () => {
        assert.equal(app.isOddOrEven(7), undefined);
    });
    it('Should return undefined with object parameter', () => {
        assert.equal(app.isOddOrEven({name: 'Don'}), undefined);
    });
    it('Should return correct results with miltiple checks', () => {
        assert.equal(app.isOddOrEven('cat'), 'odd');
        assert.equal(app.isOddOrEven('mouse'), 'odd');
        assert.equal(app.isOddOrEven('dog'), 'odd');
        assert.equal(app.isOddOrEven('notebook'), 'even');
        assert.equal(app.isOddOrEven('book'), 'even');
        assert.equal(app.isOddOrEven('phone'), 'odd');
        assert.equal(app.isOddOrEven('pillow'), 'even');
        assert.equal(app.isOddOrEven('bottle'), 'even');
        assert.equal(app.isOddOrEven('lamp'), 'even');
    });
})