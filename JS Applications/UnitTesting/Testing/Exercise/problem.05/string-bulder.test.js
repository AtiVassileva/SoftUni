let assert = require('chai').assert;
let StringBuilder = require('./string-builder');

describe('Test String Builder Functionality', () => {
    let sb;
    beforeEach(() => {
        sb = new StringBuilder('SoftUni');
    });

    describe('Test _verifyParam', () => {
        it('Should throw exception with invalid input data', () => {
            assert.throws(() => {
                new StringBuilder([]);
            }, 'Argument must be string');
            assert.throws(() => {
                new StringBuilder({});
            }, 'Argument must be string');
            assert.throws(() => {
                new StringBuilder(false);
            }, 'Argument must be string');
        });
    })
    describe('Test constructor', () => {

        it('Constructor should work correctly with valid argument', () => {
            assert.equal(sb.toString(), 'SoftUni');
        });

        it('Constructor should work correctly without argument', () => {
            assert.equal(sb = new StringBuilder().toString(), '');
        });

    });

    describe('Test append()', () => {
        it('Should work correctly with empty string', () => {
            sb.append('');
            assert.equal(sb.toString(), 'SoftUni');
        });
        it('Should work correctly with valid argument', () => {
            sb.append('JS');
            assert.equal(sb.toString(), 'SoftUniJS');
        });

        it('Should throw exception with invalid argument', () => {
            assert.throws(() => {
                sb.append(NaN);
            }, 'Argument must be string');
        });
    });

    describe('Test prepend()', () => {
        it('Should work correctly with empty string', () => {
            sb.prepend('');
            assert.equal(sb.toString(), 'SoftUni');
        });
        it('Should work correctly with valid argument', () => {
            sb.prepend('JS');
            assert.equal(sb.toString(), 'JSSoftUni');
        });

        it('Should throw exception with invalid argument', () => {
            assert.throws(() => {
                sb.append(undefined);
            }, 'Argument must be string');
        });
    });

    describe('Test insertAt()', () => {
        it('Should work correctly with text', () => {
            sb.insertAt('Bla', 4)
            assert.equal(sb.toString(), 'SoftBlaUni');
        });

        it('Should work correctly with a char/letter', () => {
            sb.insertAt('$', 7)
            assert.equal(sb.toString(), 'SoftUni$');
        });

        it('Should throw exception with invalid argument', () => {
            assert.throws(() => {
                sb.append(10);
            }, 'Argument must be string');
        });

    });

    describe('Test remove()', () => {
        it('Should work correctly when there is nothing left', () => {
            sb.remove(0, 7);
            assert.equal(sb.toString(), '');
        });
        it('Should work correctly when number is less the length', () => {
            sb.remove(2, 2);
            assert.equal(sb.toString(), 'SoUni');
        });

        it('Should work correctly when number is more than the length', () => {
            sb.remove(1, 9);
            assert.equal(sb.toString(), 'S');
        });
    });
});