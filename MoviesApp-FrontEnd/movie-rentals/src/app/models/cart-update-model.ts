export class CartUpdateModel {
  movieId: number;
  increase: number;
  decrease:boolean;
  movieQty:number;

constructor( id,name,price,){
  this.increase=this.movieQty++
}
public updateQty (update:number): void {
  this.movieQty +=update;
}
public cartUpdateModel(movie):void{
  console.log(movie)
  this.cartUpdateModel(movie);
  this.cartUpdateModel (this.cartUpdateModel);
}
}
