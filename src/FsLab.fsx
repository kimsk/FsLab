#I "../packages/Deedle.1.0.0/lib/net40"
#I "../packages/Deedle.RPlugin.1.0.0/lib/net40"
#I "../packages/FSharp.Charting.0.90.6/lib/net40"
#I "../packages/FSharp.Data.2.0.8/lib/net40"
#I "../packages/MathNet.Numerics.3.0.0-beta03/lib/net40"
#I "../packages/MathNet.Numerics.FSharp.3.0.0-beta03/lib/net40"
#I "../packages/RProvider.1.0.9/lib"
#I "../packages/RProvider.1.0.9/lib"
#I "../packages/R.NET.1.5.5/lib/net40"
#I "../packages/RDotNet.FSharp.0.1.2.1/lib/net40"
#r "Deedle.dll"
#r "Deedle.RProvider.Plugin.dll"
#r "System.Windows.Forms.DataVisualization.dll"
#r "FSharp.Charting.dll"
#r "FSharp.Data.dll"
#r "MathNet.Numerics.dll"
#r "MathNet.Numerics.FSharp.dll"
#r "RDotNet.dll"
#r "RDotNet.NativeLibrary.dll"
#r "RProvider.dll"
#r "RProvider.Runtime.dll"

// ***FsLab.fsx*** (DO NOT REMOVE THIS COMMENT, everything below is copied to the output)
namespace FsLab

module FsiAutoShow = 
  open FSharp.Charting
  open RProvider

  fsi.AddPrinter(fun (printer:Deedle.Internal.IFsiFormattable) -> 
    "\n" + (printer.Format()))
  fsi.AddPrinter(fun (ch:FSharp.Charting.ChartTypes.GenericChart) -> 
    ch.ShowChart(); "(Chart)")
  fsi.AddPrinter(fun (synexpr:RDotNet.SymbolicExpression) -> 
    synexpr.Print())


namespace FSharp.Charting
open FSharp.Charting
open Deedle

[<AutoOpen>]
module FsLabExtensions =
  type FSharp.Charting.Chart with
    static member Line(data:Series<'K, 'V>, ?Name, ?Title, ?Labels, ?Color, ?XTitle, ?YTitle) =
      Chart.Line(Series.observations data, ?Name=Name, ?Title=Title, ?Labels=Labels, ?Color=Color, ?XTitle=XTitle, ?YTitle=YTitle)
    static member Column(data:Series<'K, 'V>, ?Name, ?Title, ?Labels, ?Color, ?XTitle, ?YTitle) =
      Chart.Column(Series.observations data, ?Name=Name, ?Title=Title, ?Labels=Labels, ?Color=Color, ?XTitle=XTitle, ?YTitle=YTitle)
    static member Pie(data:Series<'K, 'V>, ?Name, ?Title, ?Labels, ?Color, ?XTitle, ?YTitle) =
      Chart.Pie(Series.observations data, ?Name=Name, ?Title=Title, ?Labels=Labels, ?Color=Color, ?XTitle=XTitle, ?YTitle=YTitle)
    static member Area(data:Series<'K, 'V>, ?Name, ?Title, ?Labels, ?Color, ?XTitle, ?YTitle) =
      Chart.Area(Series.observations data, ?Name=Name, ?Title=Title, ?Labels=Labels, ?Color=Color, ?XTitle=XTitle, ?YTitle=YTitle)
    static member Bar(data:Series<'K, 'V>, ?Name, ?Title, ?Labels, ?Color, ?XTitle, ?YTitle) =
      Chart.Bar(Series.observations data, ?Name=Name, ?Title=Title, ?Labels=Labels, ?Color=Color, ?XTitle=XTitle, ?YTitle=YTitle)


namespace MathNet.Numerics.LinearAlgebra
open MathNet.Numerics.LinearAlgebra
open Deedle

module Matrix =
  let inline toFrame matrix = matrix |> Matrix.toArray2 |> Frame.ofArray2D
module DenseMatrix =
  let inline ofFrame frame = frame |> Frame.toArray2D |> DenseMatrix.ofArray2
module SparseMatrix =
  let inline ofFrame frame = frame |> Frame.toArray2D |> SparseMatrix.ofArray2
module Vector =
  let inline toSeries vector = vector |> Vector.toSeq |> Series.ofValues
module DenseVector =
  let inline ofSeries series = series |> Series.values |> Seq.map (float) |> DenseVector.ofSeq
module SparseVector =
  let inline ofSeries series = series |> Series.values |> Seq.map (float) |> SparseVector.ofSeq


namespace Deedle
open Deedle
open MathNet.Numerics.LinearAlgebra

module Frame =
  let inline ofMatrix matrix = matrix |> Matrix.toArray2 |> Frame.ofArray2D
  let inline toMatrix frame = frame |> Frame.toArray2D |> DenseMatrix.ofArray2
module Series =
  let inline ofVector vector = vector |> Vector.toSeq |> Series.ofValues
  let inline toVector series = series |> Series.values |> Seq.map (float) |> DenseVector.ofSeq
