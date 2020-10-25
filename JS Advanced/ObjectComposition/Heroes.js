solve = () => {

    const figher = function (name) {
        [this.name, this.health, this.stamina] = [name, 100, 100];

        this.fight = () => {
            this.stamina--;
            console.log(`${this.name} slashes at the foe!`);
        };
    }

    const mage = function (name) {
        [this.name, this.health, this.mana] = [name, 100, 100];

        this.cast = (spell) => {
            this.mana--;
            console.log(`${this.name} cast ${spell}`);
        }
    }

    return {
        fighter: (name = '') => new figher(name),
        mage: (name = '') => new mage(name),
    }

    //2nd solution 
    // return {
    //     fighter: function (name) {
    //         return {
    //             name: name,
    //             health: 100,
    //             stamina: 100,
    //             fight: function () {
    //                 this.stamina--;
    //                 console.log(`${this.name} slashes at the foe!`);
    //             }
    //         }
    //     },
    //     mage: function (name) {
    //         return {
    //             name: name,
    //             health: 100,
    //             mana: 100,
    //             cast: function (spell) {
    //                 this.mana--;
    //                 console.log(`${this.name} cast ${spell}`);
    //             }
    //         }
    //     }
    // }
}

let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight()

console.log(scorcher2.stamina);
console.log(scorcher.mana);