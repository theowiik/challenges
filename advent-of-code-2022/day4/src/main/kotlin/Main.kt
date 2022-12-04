import java.io.File

fun main(args: Array<String>) {
  val path = getResourcePath("data.dat") ?: throw Exception("File does not exist")

  var fullyWithin = 0
  var overlaps = 0
  File(path).forEachLine {
    val a = getMinMax(it.split(",").first())
    val b = getMinMax(it.split(",").last())

    if (contains(a, b) or contains(b, a)) fullyWithin++
    if (overlaps(a, b)) overlaps++
  }

  println("Contains: $fullyWithin")
  println("Overlaps: $overlaps")
}

fun overlaps(p1: Pair<Int, Int>, p2: Pair<Int, Int>): Boolean {
  if (contains(Pair(p1.first, p1.first), p2) or contains(Pair(p2.first, p2.first), p1)) return true
  if (contains(Pair(p1.second, p1.second), p2) or contains(Pair(p2.second, p2.second), p1)) return true

  return false
}

fun contains(shouldBeWithin: Pair<Int, Int>, target: Pair<Int, Int>): Boolean =
  shouldBeWithin.first >= target.first && shouldBeWithin.second <= target.second

fun getResourcePath(path: String): String? =
  object {}.javaClass.getResource(path)?.path

fun getMinMax(str: String): Pair<Int, Int> =
  Pair(str.split('-').first().toInt(), str.split('-').last().toInt())
