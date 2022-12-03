package main

import (
	"bufio"
	"os"
	"strings"
)

var alphabet = []string{"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

func main() {
	readFile, _ := os.Open("data")

	fileScanner := bufio.NewScanner(readFile)
	fileScanner.Split(bufio.ScanLines)

	sum := 0
	i := 0
	three := make([]string, 3)
	for fileScanner.Scan() {
		current := fileScanner.Text()

		if i%3 == 0 {
			three[0] = current
		} else if i%3 == 1 {
			three[1] = current
		} else if i%3 == 2 {
			three[2] = current
		}

		if i%3 != 2 {
			i++
			continue
		}
		i++

		dupe := findDuplicate(three[0], three[1], three[2])
		sum += getPoints(dupe, alphabet)

	}

	readFile.Close()

	println(sum)
}

func findDuplicate(s1 string, s2 string, s3 string) string {
	a1 := strings.Split(s1, "")
	a2 := strings.Split(s2, "")
	a3 := strings.Split(s3, "")

	// Could be done with a map, but this is more fun 😈
	// (and dont care about performance here as I am just learning golang)
	for _, v := range a1 {
		for _, v2 := range a2 {
			for _, v3 := range a3 {
				if v == v2 && v == v3 {
					return v
				}
			}
		}
	}

	panic("No duplicate found")
}

func getPoints(findMe string, list []string) int {
	isCap := findMe == strings.ToUpper(findMe)

	for i, v := range list {

		if v == strings.ToUpper(findMe) {
			if isCap {
				score := 26 + (i + 1)
				println("Found", findMe, "with score", score)
				return score
			} else {
				score := (i + 1)
				return score
			}
		}
	}

	return -1
}
