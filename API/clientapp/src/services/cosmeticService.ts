import {Cosmetic, ICosmetic} from "../apptypes";
import http from "./httpService";


function getAll(handleCosmeticsLoad: Function){
    http.get<Cosmetic[]>("Cosmetics").then(x => handleCosmeticsLoad(x.data));
}

const cosmeticService = {
    getAll
}

export default cosmeticService;