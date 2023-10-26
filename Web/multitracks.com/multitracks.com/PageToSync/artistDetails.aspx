<%@ Page Language="C#" AutoEventWireup="true" CodeFile="artistDetails.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <!-- set the viewport width and initial-scale on mobile devices -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no" />

    <!-- set the encoding of your site -->
    <meta charset="utf-8">
    <title>MultiTracks.com</title>
    <!-- include the site stylesheet -->

    <link media="all" rel="stylesheet" href="./css/index.css">
</head>
<body class="premium standard u-fix-fancybox-iframe">
    <form>
        <noscript>
            <div>Javascript must be enabled for the correct page display</div>
        </noscript>

        <!-- allow a user to go to the main content of the page -->
        <a class="accessibility" href="#main" tabindex="21">Skip to Content</a>

        <div class="wrapper mod-standard mod-gray">

            <div class="details-banner">
                <div class="details-banner--overlay"></div>
                <div class="details-banner--hero">
                    <asp:Image ID="artistBannerImage" CssClass="details-banner--hero--img" runat="server" />
                </div>
                <div class="details-banner--info">
                    <a href="#" class="details-banner--info--box">
                        <asp:Image CssClass="details-banner--info--box--img" ID="artistImage" runat="server" />
                    </a>
                    <h1 class="details-banner--info--name">
                        <asp:Label ID="artistNameLabel" CssClass="details-banner--info--name--link" runat="server"></asp:Label>
                    </h1>
                </div>
            </div>


            <nav class="discovery--nav">
                <ul class="discovery--nav--list tab-filter--list u-no-scrollbar">
                    <li class="discovery--nav--list--item tab-filter--item is-active">
                        <a class="tab-filter" href="../artists/details.aspx">Overview</a>
                    </li>
                    <li class="discovery--nav--list--item tab-filter--item">
                        <a class="tab-filter" href="../artists/songs/details.aspx">Songs</a>
                    </li>
                    <li class="discovery--nav--list--item tab-filter--item">
                        <a class="tab-filter" href="../artists/albums/details.aspx">Albums</a>
                    </li>
                </ul>
                <!-- /.browse-header-filters -->
            </nav>
            <div>
                <!-- Repeater for the artist and songs -->


                <div class="discovery--container u-container">
                    <main class="discovery--section">
                        <section class="standard--holder">
                            <div class="discovery--section--header">
                                <h2>Top Songs</h2>
                                <a class="discovery--section--header--view-all" href="#">View All</a>
                            </div>
                            <!-- /.discovery-select -->
                            <asp:Repeater runat="server" ID="getArtistAndSongDetails">
                                <ItemTemplate>
                                    <ul class="song-list mod-new mod-menu">

                                        <li class="song-list--item media-player--row">

                                            <div class="song-list--item--player-img media-player">
                                                <img class="song-list--item--player-img--img"
                                                    srcset="<%#Eval("albumIMG") %>"
                                                    src="<%#Eval("albumIMG") %>" alt="Way Maker">
                                            </div>

                                            <div class="song-list--item--right">

                                                <a href="#" class="song-list--item--primary"><%#Eval("songName") %></a>
                                                <a class="song-list--item--secondary"><%#Eval("albumName") %></a>
                                                <a class="song-list--item--secondary"><%#Eval("bpm") %></a>
                                                <a class="song-list--item--secondary">4/4</a>
                                                <div class="song-list--item--icon--holder">
                                                    <a href="#" class="song-list--item--icon--wrap" style="display: inline-block">
                                                        <svg class="song-list--item--icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" id="ds-tracks-sm">
                                                            <path fill-rule="evenodd" clip-rule="evenodd" d="M1.977 12c0-5.523 4.477-10 10-10s10 4.477 10 10-4.477 10-10 10-10-4.477-10-10zm4.04 6.204a8.579 8.579 0 005.96 2.405c4.747 0 8.61-3.862 8.61-8.609 0-4.746-3.863-8.609-8.61-8.609a8.573 8.573 0 00-5.893 2.343h6.598a.708.708 0 110 1.415H4.87c-.29.423-.543.875-.754 1.348h11.213a.708.708 0 110 1.415H3.624c-.109.437-.184.888-.223 1.35h14.637a.708.708 0 110 1.414H3.396c.037.46.109.911.215 1.348h13.025a.708.708 0 010 1.416H4.087c.207.473.454.923.739 1.349h9.164a.708.708 0 110 1.415H6.017z" fill=""></path></svg>
                                                    </a>
                                                </div>
                                            </div>
                                            <!-- /.song-list-item-right -->
                                        </li>
                                    </ul>
                                </ItemTemplate>
                            </asp:Repeater>

                        </section>
                        <!-- /.songs-section -->

                        <!-- Repeater for the albums -->

                        <div class="discovery--section--header">
                            <h2>Albums</h2>
                            <a class="discovery--section--header--view-all" href="/artists/default.aspx">View All</a>
                        </div>
                        <div class="discovery--space-saver">
                            <section class="standard--holder">
                                <!-- /.discovery-select -->

                                <div class="discovery--grid-holder">

                                    <div class="ly-grid ly-grid-cranberries">

                                        <asp:Repeater ID="getAlbumDetails" runat="server">
                                            <ItemTemplate>
                                                <div class="media-item">
                                                    <a class="media-item--img--link" href="#" tabindex="0">
                                                        <img class="media-item--img" alt="Reckless Love" src="<%#Eval("albumIMG") %>" srcset="<%#Eval("albumIMG") %>, <%#Eval("albumIMG") %>">
                                                        <span class="image-tag">Master</span>
                                                    </a>
                                                    <a class="media-item--title" href="#" tabindex="0">Reckless Love</a>
                                                    <a class="media-item--subtitle" href="#" tabindex="0">Cory Asbury</a>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <!-- /.grid -->
                                </div>
                                <!-- /.discovery-grid-holder -->
                            </section>
                            <!-- /.songs-section -->
                        </div>
                        <!-- Repeater for the biography -->
                        <section class="standard--holder">
                            <div class="discovery--section--header">
                                <h2>Biography</h2>
                            </div>
                            <!-- /.discovery-section-header -->

                            <div class="artist-details--biography biography">
                                <p>
                                    <asp:Label ID="biographyLabel" runat="server" Text=""><%#Eval("biography") %></asp:Label>
                                </p>
                                <a href="#">Read More...</a>
                            </div>
                        </section>


                    </main>
                    <!-- /.discovery-section -->
                </div>


                <!-- /.biography-section -->
                <!-- /.discovery-section -->
            </div>
            <!-- /.standard-container -->
        </div>
        <!-- /.wrapper -->






        <a class="accessibility" href="#wrapper" tabindex="20">Back to top</a>
    </form>
</body>
</html>
