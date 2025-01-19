import styled from "styled-components";

export const MainTitle = styled.h1<Dimensions>`
  font-size: 1.6rem;
  color: var(--foreground);
  font-weight: bold;
  text-align: ${({ align }) => align || "center"};
  margin: 0 0 20px 0;
  font-size: ${({ hg }) => hg || "1.5rem"};
`;
