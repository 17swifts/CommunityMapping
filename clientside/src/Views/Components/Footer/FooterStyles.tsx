import styled from 'styled-components';

export const Box = styled.div`
padding: 5px 60px;
background: #ffffff;
bottom: 0;
width: 100%;
height: auto;
overflow: hidden;
box-shadow: 4px 4px 10px #888888;

@media (max-width: 1000px) {
	padding: 5px 30px;
}
`;

export const Container = styled.div`
display: flex;
flex-direction: column;
justify-content: center;
max-width: 1000px;
margin: 0 auto;
height: auto;
`

export const Column = styled.div`
display: flex;
flex-direction: column;
text-align: left;
margin-left: 60px;
`;

export const Row = styled.div`
display: grid;
grid-template-columns: repeat(auto-fill,
						minmax(185px, 1fr));
grid-gap: 5px;

@media (max-width: 1000px) {
	grid-template-columns: repeat(auto-fill,
						minmax(200px, 1fr));
}
`;

export const FooterLink = styled.a`
color: #fff;
margin-bottom: 5px;
font-size: 11px;
text-decoration: none;

&:hover {
	transition: 200ms ease-in;
}
`;

export const Heading = styled.p`
font-size: 12px;
color: #fff;
margin-bottom: 10px;
font-weight: bold;
`;

export const Image = styled.img`
height: 35px;
width: 35px;
`;

export const Copyright = styled.div`
background: white;
display: flex;
text-align: left;
width: 100%;
`;