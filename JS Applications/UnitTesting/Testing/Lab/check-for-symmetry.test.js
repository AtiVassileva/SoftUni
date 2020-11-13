let assert = require('chai').assert;
let app = require('./check-for-symmetry');

describe('Test check for symmtery functionality', () => {
    it('Should return false with a non-array input', () => {
        assert.equal(app.isSymmetric({}), false);
        assert.equal(app.isSymmetric(45), false);
        assert.equal(app.isSymmetric('hello'), false);
    });

    it('Should return true for a symmetric array', () => {
        let array = [1, 2, 3, 2, 1];
        assert.equal(app.isSymmetric(array), true);
    });

    it('Should return false for a non-symmetric array', () => {
        let array = ['C#', 'JS', 'Java', 'Python', 'Unity', 'Swift'];
        assert.equal(app.isSymmetric(array), false);
    });

    it('Should return true with an empty array', () => {
        assert.equal(app.isSymmetric([]), true);
    });

    it('Should return true with different types of values', () => {
        let arr = [{}, 1, 'hello', true, undefined, undefined, true, 'hello', 1, {}];
        assert.equal(app.isSymmetric(arr), true);
    })
});