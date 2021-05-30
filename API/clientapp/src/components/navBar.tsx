import React from "react";
import {AppBar, Button, createStyles, makeStyles, Theme, Toolbar, Typography} from '@material-ui/core';
import {Link as RouterLink} from "react-router-dom";
import {grey, teal} from '@material-ui/core/colors';

const linkColor = grey[50];
const currentLinkColor = teal["A700"];

const useStyles = makeStyles((theme: Theme) =>
    createStyles({
        grow: {
            flexGrow: 1,
        },
        menuButton: {
            marginRight: theme.spacing(2),
        },
        title: {
            display: 'none',
            [theme.breakpoints.up('sm')]: {
                display: 'block',
            },
            width: "20%",
            textAlign: "center"
        },
        sectionDesktop: {
            display: 'none',
            [theme.breakpoints.up('md')]: {
                display: 'flex',
            },
        },
        sectionMobile: {
            display: 'flex',
            [theme.breakpoints.up('md')]: {
                display: 'none',
            },
        },
        linkItem: {
            color: linkColor
        },
        currentLink: {
            color: currentLinkColor
        }
    }),
);


function NavBar() {
    const {title, linkItem, currentLink} = useStyles();
    const [index, setIndex] = React.useState(0);

    const handleClick = (event: React.MouseEvent<HTMLAnchorElement, MouseEvent>,
                         index: number) => {
        setIndex(index);
    }

    return (
        <AppBar position="sticky" color="primary">

            <Toolbar>
                <Typography className={title} variant="h4">CSIS</Typography>
                <Button
                    onClick={(event: React.MouseEvent<HTMLAnchorElement, MouseEvent>) => handleClick(event, 1)}
                    component={RouterLink}
                    to="/Cosmetics"
                >
                    <Typography variant="h6" className={index === 1 ? currentLink : linkItem}>
                        Cosmetics
                    </Typography>
                </Button>
                <Button
                    onClick={(event: React.MouseEvent<HTMLAnchorElement, MouseEvent>) => handleClick(event, 2)}
                    component={RouterLink}
                    to="/Clients"
                >
                    <Typography variant="h6" className={index === 2 ? currentLink : linkItem}>
                        Clients
                    </Typography>
                </Button>
                <Button
                    onClick={(event: React.MouseEvent<HTMLAnchorElement, MouseEvent>) => handleClick(event, 3)}
                    component={RouterLink}
                    to="/Consignments"
                >
                    <Typography variant="h6" className={index === 3 ? currentLink : linkItem}>
                        Consignments
                    </Typography>
                </Button>
                <Button
                    onClick={(event: React.MouseEvent<HTMLAnchorElement, MouseEvent>) => handleClick(event, 4)}
                    component={RouterLink}
                    to="/Purchases"
                >
                    <Typography variant="h6" className={index === 4 ? currentLink : linkItem}>
                        Purchases
                    </Typography>
                </Button>
            </Toolbar>
        </AppBar>
    );
}

export default NavBar;
