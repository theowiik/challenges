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
	for fileScanner.Scan() {
		current := fileScanner.Text()

		l := len(current)
		first := current[0 : l/2]
		second := current[l/2 : l]

		dupe := findDuplicate(first, second)
		sum += getPoints(dupe, alphabet)
	}

	readFile.Close()

	println(sum)
}

func findDuplicate(s1 string, s2 string) string {
	a1 := strings.Split(s1, "")
	a2 := strings.Split(s2, "")

	// No contains in go? 😳
	for _, v := range a1 {
		for _, v2 := range a2 {
			if v == v2 {
				return v
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
