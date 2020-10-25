function Spy(target, methodName) {
    let result = {
        count: 0
    };

    let originalMethod = target[methodName];

    target[methodName] = function (...params) {
        result.count++;

        return originalMethod.apply(target, params);
    };

    return result;
}

let spy = Spy(console,"log");

console.log(spy); // { count: 1 }
console.log(spy); // { count: 2 }
console.log(spy); // { count: 3 }