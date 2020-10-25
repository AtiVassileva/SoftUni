function solution(first) {
    return function add(second) {
        first + second;
    };
};

let add7 = solution(7);
console.log(add7(2));
console.log(add7(3));