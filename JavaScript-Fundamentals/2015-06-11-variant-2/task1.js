function solve(args) {
    let arr = args[0].split(' ').map(Number);

    console.log(Math.max(findMaxRocks(arr), findMaxRocks(arr, true)));

    function findMaxRocks(arr, isUp) {
        let current,
            count = 0,
            best = -1;

        isUp = !!isUp;
        [current, ...arr] = arr;
        
        for (let height of arr) {
            if (isUp) {
                if (current >= height) {
                    isUp = !isUp;
                    best = Math.max(best, count);
                    count = 0;
                }
            }
            else {
                if (current <= height) {
                    isUp = !isUp;
                }
            }
            count += 1;
            current = height;
        }
        return Math.max(best, count);
    }
}

module.exports = solve;