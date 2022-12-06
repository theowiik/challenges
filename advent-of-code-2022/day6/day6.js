const fs = require('fs');
const line = fs.readFileSync('data').toString();

// "a bacd xxx" // 5
// "0 1234 56789" // 1 + 4 = 5

let i = 0;
const finished = { partOne: false, partTwo: false };

for (char in line) {
  const startOfPacket = line.substring(i, i + 4).split('');
  const startOfMessage = line.substring(i, i + 14).split('');

  const hasStartOfPacket = startOfPacket.some(
    (c) => startOfPacket.indexOf(c) !== startOfPacket.lastIndexOf(c)
  );

  const hasStartOfMessage = startOfMessage.some(
    (c) => startOfMessage.indexOf(c) !== startOfMessage.lastIndexOf(c)
  );

  if (!hasStartOfPacket && !finished.partOne) {
    console.log(`Part 1: ${i + 4}`);
    finished.partOne = true;
  }

  if (!hasStartOfMessage && !finished.partTwo) {
    console.log(`Part 2: ${i + 14}`);
    finished.partTwo = true;
  }

  if (finished.partOne && finished.partTwo) break;

  i++;
}
