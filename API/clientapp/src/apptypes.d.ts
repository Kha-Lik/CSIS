export interface ICosmetic{
    Id: number;
    Name: string;
    Price: number;
    DeliveryTime: number;
    ShelfLife: number;
}

export class Cosmetic implements ICosmetic{
    Id;
    Name;
    Price;
    DeliveryTime;
    ShelfLife;

    constructor(id: number, name: string, price: number, deliveryTime: number, shelfLife: number) {
        this.Id = id;
        this.Name = name;
        this.Price = price;
        this.DeliveryTime = deliveryTime;
        this.ShelfLife = shelfLife;
    }
}