let { assert } = require('chai');
let PaymentPackage = require('./payment-package');

describe('Test Payment Package functionality', () => {
    let paymentPac;

    beforeEach(() => {
        paymentPac = new PaymentPackage('HR Services', 1500);
    });

    describe('Test constructor', () => {
        it('Should set correct property values upon initialization', () => {
            assert.equal(paymentPac.name, 'HR Services');
            assert.equal(paymentPac.value, 1500);
            assert.equal(paymentPac.VAT, 20);
            assert.equal(paymentPac.active, true);
        });
    });

    describe('Test getters and setters of name', () => {
        it('get name() should work correctly', () => {
            assert.equal(paymentPac.name, 'HR Services');
        });

        it('set name() should work correctly with valid argument', () => {
            paymentPac.name = 'Consultation';
            assert.equal(paymentPac.name, 'Consultation');
        });

        it('set name() should throw exception with an empty string', () => {
            assert.throws(() => {
                paymentPac.name = '';
            }, 'Name must be a non-empty string');
        });

        it('set name() should throw exception with a non-string argument', () => {
            assert.throws(() => {
                paymentPac.name = 6;
            }, 'Name must be a non-empty string');
        });
    });

    describe('Test getters and setters of value', () => {
        it('get value() should work correctly', () => {
            assert.equal(paymentPac.value, 1500);
        });

        it('set value() should work correctly with valid argument', () => {
            paymentPac.value = 2000;
            assert.equal(paymentPac.value, 2000);
        });

        it('set value() should throw exception with not a number argument', () => {
            assert.throws(() => {
                paymentPac.value = [];
            }, 'Value must be a non-negative number');
        });

        it('set value() should throw exception with a negative number', () => {
            assert.throws(() => {
                paymentPac.value = -1;
            }, 'Value must be a non-negative number');
        });
    });

    describe('Test getters and setters of VAT', () => {
        it('get VAT() should work correctly', () => {
            assert.equal(paymentPac.VAT, 20);
        });

        it('set VAT() should work correctly with valid argument', () => {
            paymentPac.VAT = 30;
            assert.equal(paymentPac.VAT, 30);
        });

        it('set VAT() should throw exception with not a number argument', () => {
            assert.throws(() => {
                paymentPac.VAT = false;
            }, 'VAT must be a non-negative number');
        });

        it('set VAT() should throw exception with a negative number', () => {
            assert.throws(() => {
                paymentPac.VAT = -5;
            }, 'VAT must be a non-negative number');
        });
    });

    describe('Test getters and setters of active', () => {
        it('get active() should work correctly', () => {
            assert.equal(paymentPac.active, true);
        });

        it('set active() should work correctly with valid argument', () => {
            paymentPac.active = false;
            assert.equal(paymentPac.active, false);
        });

        it('set active() should throw exception with not a boolean argument', () => {
            assert.throws(() => {
                paymentPac.active = [];
            }, 'Active status must be a boolean');

            assert.throws(() => {
                paymentPac.active = 'in progress...';
            }, 'Active status must be a boolean');
        });
    });
  
    describe('Test toString()', () => {
        it('Should return correct result', () => {
            let output = [
                `Package: ${paymentPac.name}` + (paymentPac.active === false ? ' (inactive)' : ''),
                `- Value (excl. VAT): ${paymentPac.value}`,
                `- Value (VAT ${paymentPac.VAT}%): ${paymentPac.value * (1 + paymentPac.VAT / 100)}`,
            ].join('\n');
    
            assert.equal(paymentPac.toString(), output);
        });

        it('Should return correct result', () => {
            paymentPac.VAT = 10;
            let output = [
                `Package: ${paymentPac.name}` + (paymentPac.active === false ? ' (inactive)' : ''),
                `- Value (excl. VAT): ${paymentPac.value}`,
                `- Value (VAT ${paymentPac.VAT}%): ${paymentPac.value * (1 + paymentPac.VAT / 100)}`,
            ].join('\n');
    
            assert.equal(paymentPac.toString(), output);
        });

        it('Should return correct result', () => {
            paymentPac.active = false;
            let output = [
                `Package: ${paymentPac.name}` + (paymentPac.active === false ? ' (inactive)' : ''),
                `- Value (excl. VAT): ${paymentPac.value}`,
                `- Value (VAT ${paymentPac.VAT}%): ${paymentPac.value * (1 + paymentPac.VAT / 100)}`,
            ].join('\n');
    
            assert.equal(paymentPac.toString(), output);
        });
    });
});