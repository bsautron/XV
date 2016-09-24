rm -rf .git/hooks
ln -s `pwd`/.bin/hooks .git/
git config pull.rebase true
