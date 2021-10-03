import React from "react";
import Logo from "../../../assets/img/logo_favicon-3.png"
import {
Box,
Container,
Row,
Column,
FooterLink,
Heading,
Image,
Copyright,
} from "./FooterStyles";

const Footer = () => {
return (
    <div>
        <Box>
            <Container>
                <Row>
                <Column>
                    <Heading>My Community Mapping</Heading>
                    <Image src={Logo}></Image>
                </Column>
                <Column>
                    <Heading>About Us</Heading>
                    <FooterLink href="http://www.communityinfo.org.au/">Our Vision</FooterLink>
                    <FooterLink href="https://www.mycommunitydiary.com.au/">My Community Diary</FooterLink>
                    <FooterLink href="https://www.mycommunitydirectory.com.au/">My Community Directory</FooterLink>
                </Column>
                <Column>
                    <Heading>Maps</Heading>
                    <FooterLink href="/communityprofile">SEIFA Index Map</FooterLink>
                    <FooterLink href="/serviceprofile">Community Services Map</FooterLink>
                    <FooterLink href="/servicedashboard">Analytics Dashboard</FooterLink>
                </Column>
                <Column>
                    <Heading>Contact Us</Heading>
                    <FooterLink href="#">Our Team</FooterLink>
                    <FooterLink href="http://www.communityinfo.org.au/community-information-exchange.html">Community Information Exchange</FooterLink>
                </Column>
                </Row>
            </Container>
        </Box>
    <Copyright>
    <p style={{ color: "grey",
            textAlign: "left",
            fontSize: "8px",
            padding: "5px 20px" }}>© Copyright 2021 My Community Mapping - version 1.2.11</p>
    </Copyright>
    </div>
);
};
export default Footer;
