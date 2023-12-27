import BookSearch from "./Components/BookSearch";
import Home from "./Components/Home";
import BookClubs from "./Components/BookClubs";
import FavBooks from "./Components/FavBooks";
import MyBookClubs from "./Components/MyBookClubs";
import SelectedClub from "./Components/SelectedClub";

const AppRoutes = [
  {
    index: true,
    element: <MyBookClubs />,
  },
  {
    path: "/booksearch",
    element: <BookSearch />,
  },
  {
    path: "/favbooks",
    element: <FavBooks />,
  },
  {
    path: "/bookclubs",
    element: <BookClubs />,
  },
  {
    path: "/selectedClub",
    element: <SelectedClub/>,
  },
];

export default AppRoutes;
