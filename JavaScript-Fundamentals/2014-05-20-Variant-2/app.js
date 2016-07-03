let c1 = 11,
    c2 = 200,
    c3 = 300;

let s = 20;
let best = -1;

for (let i = 0; i < s / c1; i += 1) {
    for (let j = 0; j < s / c2; j += 1) {
        for (let k = 0; k < s / c3; k += 1) {
            let price = i * c1 + j * c2 + k * c3;
            if (price <= s) {
                best = Math.max(best, price);
            }
        }
    }
}

console.log(best);