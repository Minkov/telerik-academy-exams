/* globals console module*/

function solve(args) {
    let rows = +args[0];

    let board = args.slice(2, rows + 2);

    let moves = args.slice(rows + 2 + 1)
        .map(parseMove);

    moves.forEach(move => {
        let piece = board[move.rowFrom][move.colFrom];
        if (isEmpty(piece)) {
            console.log("no");
            return;
        }

        if (isRook(piece) &&
            move.rowFrom !== move.rowTo &&
            move.colFrom !== move.colTo) {
            console.log("no");
            return;
        }

        if (isBishop(piece) &&
            (move.rowFrom === move.rowTo ||
                move.colFrom === move.colTo)) {
            console.log("no");
            return;
        }

        let rowUpdate = getValueUpdate(move.rowFrom, move.rowTo);
        let colUpdate = getValueUpdate(move.colFrom, move.colTo);

        let row = move.rowFrom + rowUpdate,
            col = move.colFrom + colUpdate;

        while (board[row] && board[row][col]) {
            if (!isEmpty(board[row][col])) {
                console.log("no");
                return;
            }
            else if (row === move.rowTo && col === move.colTo) {
                console.log("yes");
                return;
            }

            row += rowUpdate;
            col += colUpdate;
        }

        console.log("no");
    });

    function parseMove(moveStr) {
        let moveParts = moveStr.split(" ");

        return {
            "rowFrom": getRowMap(moveParts[0][1]),
            "colFrom": getColMap(moveParts[0][0]),
            "rowTo": getRowMap(moveParts[1][1]),
            "colTo": moveParts[1][0]
        };
    }

    function isEmpty(piece) {
        return piece === "-";
    }

    function isRook(piece) {
        return piece === "R";
    }

    function isBishop(piece) {
        return piece === "B";
    }

    function getValueUpdate(from, to) {
        if (from === to) {
            return 0;
        }

        else if (from < to) {
            return +1;
        }

        return -1;
    }

    function getRowMap(row) {
        return rows - row;
    }

    function getColMap(col) {
        const aCharCode = "a".charCodeAt(0);
        return col.charCodeAt(0) - aCharCode;
    }
}

module.exports = solve;