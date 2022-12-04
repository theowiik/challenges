import java.io.File

fun main(args: Array<String>) {
  val path = getResourcePath("data.dat") ?: throw Exception("File does not exist")

  var sum = 0
  File(path).forEachLine {
    val a = getMinMax(it.split(",").first())
    val b = getMinMax(it.split(",").last())

    if (isWithin(a, b) or isWithin(b, a)) sum++
  }

  println("Total: $sum")
}

fun isWithin(shouldBeWithin: Pair<Int, Int>, target: Pair<Int, Int>): Boolean =
  shouldBeWithin.first >= target.first && shouldBeWithin.second <= target.second

fun getResourcePath(path: String): String? =
  object {}.javaClass.getResource(path)?.path

fun getMinMax(str: String): Pair<Int, Int> =
  Pair(str.split('-').first().toInt(), str.split('-').last().toInt())
