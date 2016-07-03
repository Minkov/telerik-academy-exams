/* globals module, console */

function solve(args) {
    "use strict";
    let k = +args[0].split(" ")[1],
        arr = args[1].split(" ").map(Number);

    for (let i = 0; i < k; i += 1) {
        let numbers = arr.map((number, index, all) => {
            let prev =
                (index === 0)
                    ? all.length - 1
                    : index - 1,
                next = (index === (all.length - 1))
                    ? 0
                    : index + 1;

            if (number === 0) {
                return Math.abs(all[prev] - all[next]);
            } else if (number === 1) {
                return all[prev] + all[next];
            } else if (number & 1) {
                return Math.min(all[prev], all[next]);
            }

            return Math.max(all[prev], all[next]);
        });
        arr = [...numbers];
    }
    console.log(arr.reduce((s, n) => s + +n));
}

module.exports = solve;