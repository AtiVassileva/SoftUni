function extendClass(classToExtend) {
    classToExtend.prototype.species = 'Human';
    classToExtend.prototype.toSpeciesString = function(){
        return `I am a ${this.species}. ${this.toString()}>"`
    }
}

class Person {
    constructor(name) {
        this.name = name;
    }

    toString(){
        return `Hello, I'm ${this.name}`
    }
}
extendClass(Person);