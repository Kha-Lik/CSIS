import React, {Component} from 'react';
import cosmeticService from "../services/cosmeticService";
import {ICosmetic} from "../apptypes";
import {Column} from "./common/commonTypes";
import {Button} from "@material-ui/core";
import Table from "./common/table";

class CosmeticsTable extends Component {
    state = {cosmetics: Array<ICosmetic>(), columns: Array<Column>()}

    constructor(props: any) {
        super(props);
        const columns: Array<Column> = [
            {
                path: "Name",
                label: "Name"
            },
            {
                path: "Price",
                label: "Price"
            },
            {
                path: "DeliveryTime",
                label: "DeliveryTime"
            },
            {
                path: "ShelfLife",
                label: "ShelfLife"
            },
            {
                key: "delete",
                content: (cosmetic : ICosmetic) => (<Button variant={"contained"}>Delete</Button>)
            },
            {
                key: "edit",
                content: (cosmetic : ICosmetic) => (<Button variant={"contained"}>Edit</Button>)
            }
        ]
    }

    componentDidMount() {
        cosmeticService.getAll(this.handleCosmeticsLoad);
    };

    handleCosmeticsLoad = (cosmetics: Array<ICosmetic>) => {
        this.setState({cosmetics})
    };

    render() {
        const {cosmetics, columns} = this.state;
        console.log(cosmetics[2]);
        return (
            <div>
                <Table
                columns={columns}
                sortColumn={{path: "Name", order: "asc"}}
                onSort={() => {
                    console.log()}}
                data={cosmetics}
                idProperty={"Id"}
            />
            </div>
        );
    }
}

export default CosmeticsTable;