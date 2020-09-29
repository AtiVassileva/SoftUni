class List {

    constructor() {
        this.data = [];
        this.size = 0;
    }

    add(element) {
        this.data.push(element);
        this.data.sort((a, b) => a - b);
        this.size++;
    }

    remove(index) {
        this._validateIndex(index);
        this.data.splice(index, 1);
        this.size--;
    }

    get(index) {
        this._validateIndex(index);
        return this.data[index];
    }

    _validateIndex(index) {
        if (index < 0 || index >= this.data.length) {
            throw new Error('Index is outside of bounds of the list!');
        }
    }

}

let list = new List();
list.add(5);
list.add(3);
list.remove(0);

console.log(list.size); //1

