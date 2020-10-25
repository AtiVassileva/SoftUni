function add(num) {
    function sum(nextNum) {
        num += nextNum;
        return sum;
    }

    sum.toString = () => num;
    return sum;
}