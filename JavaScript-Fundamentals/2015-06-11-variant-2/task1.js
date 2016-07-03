function solve(args) {
    let initialHeights = args[0].split(' ').map(Number);

    console.log(Math.max(findMaxRocks(initialHeights), findMaxRocks(initialHeights, true)));

    function findMaxRocks(heights, isUp) {
        let current,
            count = 0,
            best = -1;

        isUp = !!isUp;
        [current, ...heights] = heights;

        for (let height of heights) {
            if (isUp) {
                if (current >= height) {
                    isUp = !isUp;
                    best = Math.max(best, count);
                    count = 0;
                }
            } else {
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