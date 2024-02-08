# Create a folder and open it in vscode
cd Desktop
mkdir GitHubPagesDemo
cd GitHubPagesDemo
code .

# test: create a html file
# initialize git and publish to github
- Ctrl + shift + g
<!-- - "Initialize repository" -->
- "Publish to GitHub
# create "gh-pages" branch
# setup pages
- open repo on github
- change visibility: public
- goto settings tab
- goto pages
- 
# push an existing repository from the command line
git remote add origin https://github.com/engr-iliyas/GitHubPagesDemo.git
git branch -M main
git push -u origin main
