function solve({ model, power, color, carriage, wheelsize }) {
    const engines = [{ power: 90, volume: 1800 }, { power: 120, volume: 2400 }, { power: 200, volume: 3500 }];
    let sizeOfWheels = wheelsize % 2 === 0 ?
        -- wheelsize: wheelsize;

    return {
        model,
        engine: engines.find(e => e.power >= power),
        carriage: { 
            type: carriage,
            color,
        },
        wheels: [0, 0, 0, 0].fill(sizeOfWheels),
    }
}