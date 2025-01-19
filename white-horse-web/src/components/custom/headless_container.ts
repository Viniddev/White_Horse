import styled from "styled-components";

export const HeadlessContainer = styled.section<Dimensions>`
  display: flex;
  align-items: center;
  justify-content: space-between;
  flex-direction: center;
  background: var(--secondaryColor);
  padding: 0px 10%;
  height: ${({ hg }) => hg || "50px"};
`;
