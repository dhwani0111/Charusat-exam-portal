<%@ Page Title="" Language="C#" MasterPageFile="~/OnlineExaminationMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="OnlineExamination.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="jquery.slidertron-1.1.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
<div id="banner">
	<div id="slider">
		<div class="viewer">
			<div class="reel">
				<div class="slide">
					<%--<h2>Conduct an Examination through internet.</h2>--%>
					
					<img src="images/Online-exam.png" alt="" width="1000px" height="400px" /> </div>
				<div class="slide">
					<%--<h2>Multiple choice Questions.</h2>
					<p>A large firm with a human touch.</p>--%>
					<img src="images/3.jpg" alt="" width="1000px" height="400px" /> </div>
                <div class="slide">
					<%--<h2>Leaders in their Field.</h2>
					<p>Common Ground. Uncommon Vision.</p>--%>
					<img src="images/4.jpg" alt="" width="1000px" height="400px" /> </div>
				<div class="slide">
					<%--<h2>Power of Collaboration.</h2>
					<p>Deeper Understanding. Better Solutions.</p>--%>
					<img src="images/5.jpg" alt="" width="1000px" height="400px" /> </div>
				<div class="slide">
					<%--<h2>Resourceful Representation.</h2>
					<p>Legal Counsel to Great Companies.</p>--%>
					<img src="images/6.jpg" alt="" width="1000px" height="400px" /> </div>
				<div class="slide">
					<%--<h2>Resourceful Representation.</h2>
					<p>Legal Counsel to Great Companies.</p>--%>
					<img src="images/7.jpg" alt="" width="1000px" height="400px" /> </div>
            </div>
		</div>
		<%--<div class="indicator">
			<ul>
				<li class="active">1</li>
				<li>2</li>
				<li>3</li>
                <li>4</li>
                <li>5</li>
                <li>6</li>
			</ul>
		</div>--%>
	</div>
	<script type="text/javascript">
	    $('#slider').slidertron({
	        viewerSelector: '.viewer',
	        reelSelector: '.viewer .reel',
	        slidesSelector: '.viewer .reel .slide',
	        advanceDelay: 3000,
	        speed: 'slow',
	        navPreviousSelector: '.previous-button',
	        navNextSelector: '.next-button',
	        indicatorSelector: '.indicator ul li',
	        slideLinkSelector: '.link'
	    });
	</script> 
</div>


<%--<div id="banner"><img src="images/header-image.jpg" width="1100" height="500" alt="" /></div>--%>

<div id="page">
		<div id="content">
			<div id="cbox1">
				<h2>What is Online Examination System?</h2>
				<p><img src="images/10.jpg" width="670" height="200" alt="" /></p>
				<p>Online examination is a new technique to conduct an examination through internet. Lot of companies is gladly taking this modern system to exemption form the tedious written examination system. Low cost, minimum effort, minimum employee deployment, saving time, instant result and conduct an examination India and abroad. </p>
				<p>The formal examination system is a very long procedure to conduct an examination. From the respect of the recruiter, they should give extra effort on the examination to select employees for the organization. This is a huge responsibility and extra load to the recruiter to conduct an examination. This is very costly and extremely tedious to conduct an examination. Side by side online examination is a very sophisticated examination conducting system. Recruiter just sends a mail to the candidates for the post and it will be reached to the millions of register candidates of worldrelation.com. You can select deserving candidates for your organization from India and abroad by this system. </p>
				
			</div>
			<%--<div id="two-column">
				<div id="tbox1">
					<h2>Mauris vulputate dolor</h2>
					<ul class="style2">
						<li class="first">
							<h3><a href="#">Maecenas luctus lectus</a></h3>
							<p><a href="#">Quisque dictum integer nisl risus, sagittis convallis, rutrum id, congue, and nibh.</a></p>
						</li>
						<li>
							<h3><a href="#">Integer gravida nibh</a></h3>
							<p><a href="#">Quisque dictum integer nisl risus, sagittis convallis, rutrum id, congue, and nibh.</a></p>
						</li>
						<li>
							<h3><a href="#">Fusce ultrices fringilla</a></h3>
							<p><a href="#">Quisque dictum integer nisl risus, sagittis convallis, rutrum id, congue, and nibh.</a></p>
						</li>
					</ul>
				</div>
				<div id="tbox2">
					<h2>Nulla luctus eleifend purus</h2>
					<ul class="style2">
						<li class="first">
							<h3><a href="#">Maecenas luctus lectus</a></h3>
							<p><a href="#">Quisque dictum integer nisl risus, sagittis convallis, rutrum id, congue, and nibh.</a></p>
						</li>
						<li>
							<h3><a href="#">Integer gravida nibh</a></h3>
							<p><a href="#">Quisque dictum integer nisl risus, sagittis convallis, rutrum id, congue, and nibh.</a></p>
						</li>
						<li>
							<h3><a href="#">Fusce ultrices fringilla</a></h3>
							<p><a href="#">Quisque dictum integer nisl risus, sagittis convallis, rutrum id, congue, and nibh.</a></p>
						</li>
					</ul>
				</div>
			</div>--%>
		</div>
		<div id="sidebar">
			<%--<div id="box1">
				<h2>References</h2>
				<ul class="style1">
					<li class="first"><a href="http://www.4tests.com/">4 Test</a></li>
					<li><a href="http://www.exam2win.com/">Exam to Win</a></li>
					<li><a href="http://www.examprofessor.com/">Exam Professor</a></li>
					<li><a href="http://www.classmarker.com/">Class Marker</a></li>
					<li><a href="http://www.tcyonline.com/india/home">TCY Online</a></li>
					<li><a href="http://www.thinkexam.com/">Think Exam</a></li>
				</ul>
				
			</div>--%>
			<div id="box2">
				<h2>About Exam</h2>
				<ul class="style3">
					<li class="first"><img src="images/11.jpg" width="78" height="78" alt="" />
						<p>Online Examination System(OES) is a Multiple Choice Questions(MCQ) based examination system that provides an easy to use environment for both Test Conducters and Students appearing for Examination. </p>
						
					</li>
					<li><img src="images/12.jpg" width="78" height="78" alt="" />
						<p>The main objective of OES is to provide all the features that an Examination System must have, with the "interfaces that doesn't Scare it's Users!". </p>
						
					</li>
					<li><img src="images/13.jpg" width="78" height="78" alt="" />
						<p>A candidate shall ordinarily work in a recognized place of research including the University Departments, Research Institutes and Affiliated Colleges recognized by the University. </p>
						
					</li>
				</ul>
				
			</div>
		</div>
	</div>

</asp:Content>
