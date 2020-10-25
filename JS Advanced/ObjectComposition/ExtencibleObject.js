moObj = () => ({
    __proto__: {},
    extend: function (template) {
        Object.entries(template).forEach(([key, value]) => {
            typeof value === 'function' ? this.__proto__[key] = value : this[key] = value;
        });
    }
});

function myObj(){
    this.__proto__ = {};
    function extend (template) {
        Object.entries(template).forEach((([key, value]) => {
            if (typeof value === 'function') {
                __proto__[key] = value;
            } else {
                this[key] = value;
            }
        }));
    }

    return {__proto__, extend};
}