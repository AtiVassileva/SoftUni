let assert = require('chai').assert;
let app = require('./SumOfNumbers.js');

describe('Test summing', () => {
    it('Sum should return positive result with 2 positive numbers', () => {
        assert.equal(app.sum([5, 10]), 15);
        assert.equal(app.sum([10, 20, 30]), 60);
        assert.equal(app.sum([0]), 0);
        assert.equal(app.sum([1, 2, 3, 4, 5, 6, 7, 8]), 36);
    });

    it('Sum should return negative result with negative number', () => {
        assert.equal(app.sum([-1, -2]), -3);
        assert.equal(app.sum([-1]), -1);
        assert.equal(app.sum([-5, -2]), -7);
        assert.equal(app.sum([-10, -20, -30]), -60);
    })
    it('Should work with string numbers', () => {
        assert.equal(app.sum(['1', '2', '3']), 6);
    })

    it ('should return NaN with non-parsable values', () => {
        assert.isNaN(app.sum(['hello', 'hi']));
    })
    it('Should return negative with positive and negative number', () => {
        assert.equal(app.sum([-2, 1]), -1);
        assert.equal(app.sum([-10, 9]), -1);
        assert.equal(app.sum([-2, 0]), -2);
        assert.equal(app.sum([-400, 200]), -200);
    })

    it('Should return positive with positive and negative number', () => {
        assert.equal(app.sum([-2, 5]), 3);
        assert.equal(app.sum([-10, 20]), 10);
        assert.equal(app.sum([-2, 8]), 6);
        assert.equal(app.sum([-400, 500]), 100);
    })

    it('Should return zero with empty array', () => {
        assert.equal(app.sum([]), 0);
    })
})