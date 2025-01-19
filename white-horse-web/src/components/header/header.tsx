import {HeadlessContainer} from "../custom/headless_container";
import "../../styles/globals.scss";
import "./header.scss";
import Link from "next/link";
import { PROFILE } from "../../utils/front_end_urls/urls";

export default function Header(){
    return (
      <HeadlessContainer hg="65px">
        
        <div className="flexRow">
          <img src="/logo_header.png" alt="logo" className="LogoHeader" />
          <h1>White Horse Inc.</h1>
        </div>

        <div className="flexRow">
          <Link href={PROFILE}>
            <img src="/profile.png" alt="profile" className="LogoHeader" />
          </Link>
        </div>
      
      </HeadlessContainer>
    );
}