function solve(area, vol, input) {
    let objects = JSON.parse(input);
    let result = [];

    objects.forEach(obj => {
        let currArea = area.call(obj);
        let currVol = vol.call(obj);
        let current = {'area': Math.abs(currArea), 'volume': Math.abs(currVol)};
        result.push(current);
    });

    return result;
}

function area() {
    return this.x * this.y;
};

function vol() {
    return this.x * this.y * this.z;
};