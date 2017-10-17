#Git 使用笔记

- - -

1. 初始化Git仓库，使用`git init`命令。
2. 添加文件到Git仓库：
	1. `git add<file>`
	2. `git commit`（将缓存区的命令写入）
3. 查看Git仓库当前状态：`git status`
4. 查看文件具体修改内容：`git diff<file>`
5. 在版本历史间穿梭：`git reset --hard commit_id`
6. 查看提交历史：`git log`
7. 查看命令历史：`git reflog`
8. 用版本库里的版本替换工作区的版本：`git checkout --file`
9. 丢弃暂存区修改至工作区：`git reset HEAD file`
10. 撤销本次提交：版本回退。
11. 删除工作区文件：`rm <file>`
12. 关联远程库：`git remote add origin git@server-name:path/repo-name.git`其中用户名后的自行修改。
13. 把本地库的内容推送到远程：`git push origin`,把当前分支master推送到远程。参数`-u`将本地分支和远程分支关联，适合于第一次推送中。
14. 从远程库克隆：`git clone git@server-name:path/repo-name.git`
15. 创建分支：`git branch <name>`
16. 切换分支：`git checkout <name>`
15. 创建并切换到dev分支：`git checkout -b dev`
16. 查看当前分支：`git branch`
17. 合并制定分支到当前分支：`git merge <name>`
18. 删除分支：`git branch -d <name>`
19. 查看分支合并情况：`git log` 用于解决冲突时查看。
20. 