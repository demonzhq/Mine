using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using SubSonic;

namespace DianDang
{
    public partial class ManageRoleForm : DockContent
    {
        public ManageRoleForm()
        {
            InitializeComponent();
            InitRoles();
            InitModules();
        }

        private void InitRoles()
        {
            treeRoles.Nodes.Clear();
            TreeNode rootNode;
            TreeNode tempRoleNode;
            rootNode = new TreeNode("���н�ɫ");
            treeRoles.Nodes.Add(rootNode);

            Query queryRoles = new Query(DDRole.Schema);
            DataTable dtTreeRoles=queryRoles.ExecuteDataSet().Tables[0];
            if (dtTreeRoles.Rows.Count > 0)
            {
                for (int i = 0; i < dtTreeRoles.Rows.Count; i++)
                {
                    tempRoleNode = new TreeNode(dtTreeRoles.Rows[i]["RoleName"].ToString());
                    rootNode.Nodes.Add(tempRoleNode);
                }
            }
            treeRoles.ExpandAll();
        }

        private void InitModules()
        {
            treeModules.Nodes.Clear();
            TreeNode rootNode;
            TreeNode tempModuleNode;
            TreeNode tempChildModuleNode;
            rootNode = new TreeNode("����Ȩ��");
            treeModules.Nodes.Add(rootNode);

            Query queryModules = new Query(DDModule.Schema);
            queryModules.AddWhere("ParentID", 0);
            DataTable dtTreeModules = queryModules.ExecuteDataSet().Tables[0];
            if (dtTreeModules.Rows.Count > 0)
            {
                for (int i = 0; i < dtTreeModules.Rows.Count; i++)
                {
                    tempModuleNode = new TreeNode(dtTreeModules.Rows[i]["ModuleName"].ToString());
                    rootNode.Nodes.Add(tempModuleNode);
                    Query queryChildModules=new Query(DDModule.Schema);
                    queryChildModules.AddWhere("ParentID",Convert.ToInt32(dtTreeModules.Rows[i]["ModuleID"]));
                    DataTable dtChildModules = queryChildModules.ExecuteDataSet().Tables[0];
                    if (dtChildModules.Rows.Count > 0)
                    {
                        for (int j = 0; j < dtChildModules.Rows.Count; j++)
                        {
                            tempChildModuleNode = new TreeNode(dtChildModules.Rows[j]["ModuleName"].ToString());
                            tempModuleNode.Nodes.Add(tempChildModuleNode);
                        }
                    }
                }
            }
            treeModules.ExpandAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.tbxRoleName.Text.Trim().Length > 0)
            {
                DDRole role = new DDRole();
                role.RoleName = this.tbxRoleName.Text.Trim();
                role.Save();
                InitRoles();
            }
            else
            {
                MessageBox.Show("��ɫ������Ϊ�գ�","��ʾ��Ϣ");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DDRole role = new DDRole("RoleName", treeRoles.SelectedNode.Text);
                Query queryPermission = new Query(DDPermission.Schema);
                queryPermission.AddWhere("RoleID", role.RoleID);
                queryPermission.QueryType = QueryType.Delete;
                queryPermission.Execute();

                Query queryRole = new Query(DDRole.Schema);
                queryRole.AddWhere("RoleName", treeRoles.SelectedNode.Text);
                queryRole.QueryType = QueryType.Delete;
                queryRole.Execute();

                InitRoles();
            }
            catch
            {
                MessageBox.Show("��ѡ����Ҫɾ���Ľ�ɫ��","��ʾ��Ϣ");
            }
        }

        public static void CheckControl(TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node != null && !Convert.IsDBNull(e.Node))
                {
                    CheckParentNode(e.Node);
                    if (e.Node.Nodes.Count > 0)
                    {
                        CheckAllChildNodes(e.Node, e.Node.Checked);
                    }
                }
            }
        }

        //�ı������ӽڵ��״̬
        private static void CheckAllChildNodes(TreeNode pn, bool IsChecked)
        {
            foreach (TreeNode tn in pn.Nodes)
            {
                tn.Checked = IsChecked;

                if (tn.Nodes.Count > 0)
                {
                    CheckAllChildNodes(tn, IsChecked);
                }
            }
        }

        //�ı丸�ڵ��ѡ��״̬���˴�Ϊ�����ӽڵ㲻ѡ��ʱ��ȡ�����ڵ�ѡ�У����Ը�����Ҫ�޸�
        private static void CheckParentNode(TreeNode curNode)
        {
            bool bChecked = false;

            if (curNode.Parent != null)
            {
                foreach (TreeNode node in curNode.Parent.Nodes)
                {
                    if (node.Checked)
                    {
                        bChecked = true;
                        break;
                    }
                }

                if (bChecked)
                {
                    curNode.Parent.Checked = true;
                    CheckParentNode(curNode.Parent);
                }
                else
                {
                    curNode.Parent.Checked = false;
                    CheckParentNode(curNode.Parent);
                }
            }
        }


        private void treeModules_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckControl(e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DDRole role = new DDRole("RoleName", treeRoles.SelectedNode.Text.Trim());

                Query queryDel = new Query(DDPermission.Schema);
                queryDel.AddWhere("RoleID",role.RoleID);
                queryDel.QueryType = QueryType.Delete;
                queryDel.Execute();

                TreeNode tempTreeNode;
                for (int i = 0; i < treeModules.Nodes[0].Nodes.Count; i++)
                {
                    tempTreeNode = treeModules.Nodes[0].Nodes[i];
                    for (int j = 0; j < tempTreeNode.Nodes.Count; j++)
                    {
                        if (tempTreeNode.Nodes[j].Checked == true)
                        {
                            DDModule module = new DDModule("ModuleName", tempTreeNode.Nodes[j].Text.Trim());
                            DDPermission permission = new DDPermission();
                            permission.RoleID = role.RoleID;
                            permission.ModuleID = module.ModuleID;
                            permission.Save();
                        }
                    }
                }
                MessageBox.Show("���³ɹ���","��ʾ��Ϣ");
            }
            catch
            {
                MessageBox.Show("����ʧ�ܣ��������ݿ��Ƿ�������ȷ��","��ʾ��Ϣ");
            }           
        }

        private void treeRoles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DDRole role = new DDRole("RoleName", treeRoles.SelectedNode.Text.Trim());
            TreeNode tempTreeNode;
            for (int i = 0; i < treeModules.Nodes[0].Nodes.Count; i++)
            {
                tempTreeNode = treeModules.Nodes[0].Nodes[i];
                for (int j = 0; j < tempTreeNode.Nodes.Count; j++)
                {
                    DDModule module = new DDModule("ModuleName", tempTreeNode.Nodes[j].Text.Trim());
                    Query query = new Query(DDPermission.Schema);
                    query.AddWhere("RoleID", role.RoleID);
                    query.AddWhere("ModuleID",module.ModuleID);
                    DataTable dt = query.ExecuteDataSet().Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        tempTreeNode.Nodes[j].Checked = true;
                    }
                    else
                    {
                        tempTreeNode.Nodes[j].Checked = false;
                    }
                }
            }
        }
    }
}