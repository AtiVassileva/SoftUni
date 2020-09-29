class Point {
    constructor(x, y) {
        this.x = Number(x);
        this.y = Number(y);
    }

    static distance(first, second) {

        let firstPart = Math.pow((second.x - first.x), 2);
        let secondPart = Math.pow((second.y - first.y), 2);

        let distance = Math.sqrt(firstPart + secondPart);

        return distance;
    }
}

let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));
