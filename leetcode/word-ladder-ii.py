class Solution:
    def findLadders(self, begin_word: str, end_word: str, word_list: List[str]) -> List[List[str]]:
        if end_word not in word_list:
            return []

        map = build_map(begin_word, end_word, word_list)

        return []

    def build_map(self, begin_word: str, end_word: str, word_list: List[str]) -> dict:
        map = {}

        for current in word_list:
            map[word] = []

            for w in current:
                if w == word:
                    continue

                if is_one_away(w, current):
                    map[word].append(w)

        return map

    def is_one_away(self, word_one: str, word_two: str) -> bool:
        diff = 0

        for i, _ in word_one:
            if word_one[i] != word_two[i]:
                diff += 1

        return diff == 1
