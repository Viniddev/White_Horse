import "./header.scss";
import Link from "next/link";
import { PROFILE, HOME } from "../../utils/front_end_urls/urls";
import "../../styles/globals.scss";
import { Button } from "primereact/button";

export default function Header(){
    return (
      <section className="headerLayout">
        <div className="flexRow">
          <Link href={HOME}>
            <img src="/logo_header.png" alt="logo" className="LogoHeader" />
          </Link>
          <h1 className="titleHeader">White Horse Inc.</h1>
        </div>

        <div className="flexRow">
          <Button label="Login" outlined />
          <Link href={PROFILE}>
            <img src="/profile.png" alt="profile" className="LogoHeader" />
          </Link>
        </div>
      </section>
    );
}