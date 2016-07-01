/* globals console */

function solve(args) {
    "use strict";

    const rows = +args[0],
        cols = +args[1];

    let board = args.slice(2, 2 + rows);
    let moves = args.slice(3 + rows).map(move => move.split(' '));

    moves.forEach(move => {
        let fromCol = getRow(move[0][0]);
        let fromRow = getCol(move[0][1]);

        let toCol = getRow(move[1][0]);
        let toRow = getCol(move[1][1]);

        let piece = board[fromRow][fromCol];

        if (isKnight(piece)) {
            if (isEmpty(board[toRow][toCol]) && checkKnight(fromRow, fromCol, toRow, toCol)) {
                console.log("yes");
            }
            else {
                console.log("no");
            }
        }
        else if (isQueen(piece)) {
            if (isEmpty(board[toRow][toCol]) && checkQueen(fromRow, fromCol, toRow, toCol, board)) {
                console.log("yes");
            }
            else {
                console.log("no");
            }
        }
        else {
            console.log("no");
            return;
        }

    });

    function getCol(colName) {
        return rows - colName;
    }

    function getRow(rowName) {
        const startCharCode = "a".charCodeAt(0);
        var code = rowName.charCodeAt(0);
        return code - startCharCode;
    }

    function isKnight(piece) {
        return piece === "K";
    }
    function isQueen(piece) {
        return piece === "Q";
    }
    function isEmpty(piece) {
        return piece === "-";
    }

    function checkKnight(fromRow, fromCol, toRow, toCol) {
        const knightMoves = [[-2, 1], [-1, 2], [1, 2], [2, 1], [2, -1], [1, -2], [-1, -2], [-2, -1]];
        for (let knightMove of knightMoves) {
            let newRow = fromRow + knightMove[0];
            let newCol = fromCol + knightMove[1];
            if (newRow === toRow && newCol === toCol) {
                return true;
            }
        }
        return false;
    }

    function checkQueen(fromRow, fromCol, toRow, toCol, board) {
        let queenMoves = [
            [1, 1],
            [1, -1],
            [-1, 1],
            [-1, -1],
            [1, 0],
            [-1, 0],
            [0, 1],
            [0, -1]
        ];

        let dir = getDirection(fromRow, fromCol, toRow, toCol);

        let row = fromRow + queenMoves[dir][0],
            col = fromCol + queenMoves[dir][1];
        while (true) {
            if ((row === toRow && fromRow !== toRow) ||
                (col === toCol && fromCol !== toCol) ||
                row < 0 || row > rows ||
                col < 0 || col > cols) {
                break;
            }
            let piece = board[row][col];
            if (!isEmpty(piece)) {
                return false;
            }
            row += queenMoves[dir][0];
            col += queenMoves[dir][1];
        }
        if (row === toRow && col === toCol) {
            return true;
        }
        else {
            return false;
        }
    }

    function getDirection(fromRow, fromCol, toRow, toCol) {
        if (fromRow === toRow) {
            if (fromCol < toCol) {
                return 6;
            } else {
                return 7;
            }
        } else if (fromCol === toCol) {
            if (fromRow < toRow) {
                return 4;
            } else {
                return 5;
            }
        } else if (fromRow < toRow) {
            if (fromCol < toCol) {
                return 0;
            } else {
                return 1;
            }
        } else {
            if (fromCol < toCol) {
                return 2;
            } else {
                return 3;
            }
        }
    }
}

module.exports = solve;